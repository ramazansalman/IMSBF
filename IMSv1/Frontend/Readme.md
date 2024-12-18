In immovable-management-frontend, start frontend with;

ng new immovable-management-client
Routing: Yes
CSS Framework: CSS

cd immovable-management-client

npm install bootstrap

ng add @angular/material

To use bootstrap, add this to angular.json
"styles": [
  "src/styles.css",
  "node_modules/bootstrap/dist/css/bootstrap.min.css"
]

ng serve

