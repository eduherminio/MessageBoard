# Message Board

## Setup

`setup.ps1` spins up a docker container running our Message Board locally (port 5001).

## Main trade-offs

- In-memory database.
- Lack of model and request/response DTO separation.
- Lack of message encryption.
- Poor exception handling (no custom page or custom HTTP codes/error messages per known exceptions).
- Poor man's implementation of ip detection (probably not working).
- Poor containerization.
