FROM ghcr.io/ffxivita/docker-dalamud:staging@sha256:36d533e313fc6af9b94440b98314de830f7ff566f3e42691af71e0ef833218ca

# Optout of telemtry.
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1
ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1

# Create a non-root dev user.
RUN adduser --disabled-password --gecos "" dev

# Install required dependencies.
RUN apk add --update openssh
