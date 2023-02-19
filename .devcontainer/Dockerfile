FROM ghcr.io/ffxivita/docker-dalamud:staging@sha256:e96858ecd9cba0530f7ce794038ec2698b2b65e94b5517c82b86716673415fef

# Optout of telemtry.
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1
ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1

# Create a non-root dev user.
RUN adduser --disabled-password --gecos "" dev

# Install required dependencies.
RUN apk add --update openssh
