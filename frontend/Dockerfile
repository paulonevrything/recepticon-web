FROM node:10.15.3-slim as build
WORKDIR /app
COPY src ./src
COPY *.json ./
RUN npm install -g @angular/cli@7.3.10
RUN npm install
RUN ng build --prod

FROM nginx:alpine as deploy
WORKDIR /app
COPY --from=build /app/dist/recepticon-web/*.* /usr/share/nginx/html/
COPY /nginx.conf  /etc/nginx/conf.d/default.conf