FROM ghcr.io/ffxivita/docker-dalamud:staging@sha256:4034774a013b2f58bde577c4d83bcce40d4387adcf1abb1d00bf5f11d2e56765

# Optout of telemtry.
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1
ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1

# Create a non-root dev user.
RUN adduser --disabled-password --gecos "" dev

# Install required dependencies.
RUN apk add --update openssh
