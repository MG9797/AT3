# Audio Processing Tools

This folder contains scripts for audio stem separation and basic cleanup tasks.

* `stem_separation.py` - utilities to separate vocal and drum stems, remove reverb and noise.

These scripts rely on third-party Python packages such as `librosa`,
`noisereduce`, `soundfile`, and either `spleeter` or `demucs` for stem
separation. Make sure to install the required packages before running the code:

```bash
pip install librosa noisereduce spleeter demucs soundfile
```

Due to environment constraints the models are not included in this repository and must be downloaded when installing the dependencies.
