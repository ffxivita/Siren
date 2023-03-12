FROM ghcr.io/ffxivita/docker-dalamud:staging@sha256:9c2f1142d2ec59b670d19d4f1d7db22c95a872175b44ac9577e96bc0f6846a2b

# Optout of telemtry.
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1
ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1

# Create a non-root dev user.
RUN adduser --disabled-password --gecos "" dev

# Install required dependencies.
RUN apk add --update openssh
