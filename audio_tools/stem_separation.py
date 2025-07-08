"""Utilities for audio stem separation and cleanup.

This module provides helper functions to:
  * Separate a track into vocals and accompaniment.
  * Extract the drum stem.
  * Apply simple dereverberation and noise reduction.

The code uses third-party libraries such as spleeter or demucs for stem
separation and noisereduce for noise removal. These libraries must be
installed separately.
"""
from pathlib import Path
from typing import Tuple

import librosa
import numpy as np

try:
    from noisereduce import reduce_noise
except ImportError:  # pragma: no cover - optional dependency
    reduce_noise = None

# Optional: use Spleeter or Demucs if available
try:
    from spleeter.separator import Separator
    _separator = Separator('spleeter:4stems')
except Exception:
    _separator = None


def load_audio(path: str, sr: int = 44100) -> Tuple[np.ndarray, int]:
    """Load audio file using librosa."""
    data, sample_rate = librosa.load(path, sr=sr)
    return data, sample_rate


def separate_vocals(input_path: str, output_dir: str) -> None:
    """Separate vocals and accompaniment using Spleeter if installed."""
    if _separator is None:
        raise RuntimeError('Spleeter is not installed or failed to initialize.')
    _separator.separate_to_file(input_path, output_dir)


def separate_drums(input_path: str, output_dir: str) -> None:
    """Extract drums using Spleeter's 4 stems model if available."""
    if _separator is None:
        raise RuntimeError('Spleeter is not installed or failed to initialize.')
    _separator.separate_to_file(input_path, output_dir)


def denoise_audio(audio: np.ndarray, sample_rate: int) -> np.ndarray:
    """Apply noise reduction if the noisereduce package is available."""
    if reduce_noise is None:
        raise RuntimeError('noisereduce package is required for denoising.')
    return reduce_noise(y=audio, sr=sample_rate)


def dereverb_audio(audio: np.ndarray, sample_rate: int) -> np.ndarray:
    """Simple dereverberation using spectral gating."""
    # This is a very basic implementation based on noise reduction
    if reduce_noise is None:
        raise RuntimeError('noisereduce package is required for dereverb.')
    return reduce_noise(y=audio, sr=sample_rate, stationary=True)


def save_audio(path: str, audio: np.ndarray, sample_rate: int) -> None:
    """Save audio to disk."""
    import soundfile as sf
    sf.write(path, audio, sample_rate)


def process_file(
    input_path: str,
    output_dir: str,
    *,
    separate: bool = False,
    denoise: bool = False,
    dereverb: bool = False,
    sr: int = 44100,
) -> None:
    """Run selected processing steps on an audio file."""
    audio, sample_rate = load_audio(input_path, sr=sr)

    if denoise:
        audio = denoise_audio(audio, sample_rate)
    if dereverb:
        audio = dereverb_audio(audio, sample_rate)

    Path(output_dir).mkdir(parents=True, exist_ok=True)

    if separate:
        separate_vocals(input_path, output_dir)
    else:
        out_path = str(Path(output_dir) / "processed.wav")
        save_audio(out_path, audio, sample_rate)


if __name__ == "__main__":
    import argparse

    parser = argparse.ArgumentParser(description="Audio cleanup utilities")
    parser.add_argument("input", help="Input audio file")
    parser.add_argument("output_dir", help="Directory to store results")
    parser.add_argument("--denoise", action="store_true", help="Apply noise reduction")
    parser.add_argument("--dereverb", action="store_true", help="Apply dereverb")
    parser.add_argument("--separate", action="store_true", help="Separate vocals and drums")
    args = parser.parse_args()

    process_file(
        args.input,
        args.output_dir,
        separate=args.separate,
        denoise=args.denoise,
        dereverb=args.dereverb,
    )
