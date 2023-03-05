FROM ghcr.io/ffxivita/docker-dalamud:staging@sha256:40bdc571604915370d299735c69fd79f9ca20fa7b980a6c1bdb6ac688648b420

# Optout of telemtry.
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1
ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1

# Create a non-root dev user.
RUN adduser --disabled-password --gecos "" dev

# Install required dependencies.
RUN apk add --update openssh
