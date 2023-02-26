FROM ghcr.io/ffxivita/docker-dalamud:staging@sha256:97b7e499c82207733b599ba0163ea1982d2a804c263b71c7c854cf630cc4fe65

# Optout of telemtry.
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1
ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1

# Create a non-root dev user.
RUN adduser --disabled-password --gecos "" dev

# Install required dependencies.
RUN apk add --update openssh
