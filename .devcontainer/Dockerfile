FROM ghcr.io/ffxivita/docker-dalamud:staging@sha256:9e781a1ac46a8da2f02a7acb11794d5697591e990442f284deb54fab0267f7f4

# Optout of telemtry.
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1
ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1

# Create a non-root dev user.
RUN adduser --disabled-password --gecos "" dev

# Install required dependencies.
RUN apk add --update openssh
