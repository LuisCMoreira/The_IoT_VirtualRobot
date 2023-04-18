FROM nodered/node-red:latest
USER root
RUN npm install node-red-dashboard
ADD flows.json ../../../data
USER node-red
CMD ["node-red"]