# File Encryptor

A simple file encrypting app, written using Avalonia.

## Installation and use

Use Docker to run the app.

```bash
# enable docker to use x-server
xhost +local:docker

# run the app
docker run --rm -e DISPLAY=$DISPLAY \
    -v /tmp/.X11-unix:/tmp/.X11-unix \
    -v path/to/directory:/data/files \
    danilasimanok/file-encryptor:latest
```