# AT3 Repository

This repository contains two components:

1. **DiceRoll** - A sample C# project with unit tests.
2. **audio_tools** - Python utilities for audio stem separation and basic signal cleanup.

The new audio tools can be found in `audio_tools/stem_separation.py`. They rely on third-party libraries such as `librosa`, `spleeter`, `noisereduce`, and `soundfile`. Install them using `pip` before running the script.

```bash
pip install librosa noisereduce spleeter demucs soundfile
```

Due to environment limitations in CI, the heavy models are not included and need to be downloaded during installation.

Example usage:

```bash
python -m audio_tools.stem_separation input.wav results/ --separate --denoise
```
