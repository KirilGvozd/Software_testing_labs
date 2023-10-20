FROM ubuntu:latest

RUN apt-get update && apt-get install -y \
    git \
    maven \
    openjdk-8-jdk

RUN mkdir -p /run/sshd

# JAVA_HOME
ENV JAVA_HOME /usr/lib/jvm/java-8-openjdk-amd64

# PATH
ENV PATH $PATH:$JAVA_HOME/bin


RUN useradd -m -d /home/jenkins -s /bin/bash jenkins
RUN echo "jenkins:jenkinspass" | chpasswd

CMD ["/usr/sbin/sshd", "-D"]