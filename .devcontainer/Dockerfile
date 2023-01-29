FROM ghcr.io/ffxivita/docker-dalamud:staging@sha256:367e26a70342f7395f17f9b5df5236a0bfa875e81b633892cfec645f2d211b16

# Optout of telemtry.
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1
ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1

# Create a non-root dev user.
RUN adduser --disabled-password --gecos "" dev

# Install required dependencies.
RUN apk add --update openssh
