# Basic e-Shop CRUD API
API with CRUD operations for basic e-Shop project
 
This project is an example of a CRUD API to a basic e-commerce model.
  
## Business Workflow

## Requirements/Deliverables  
- [x] Product: API to manage a business model with the following entities: customers, orders, products.  
- [x] Product: Store information
- [x] Tech: Provide a REST API to manage the proposed model 
- [x] Tech: Docker available  

## Technical Summary  
**Activities**
- [x] Business and requirements analysis  
- [x] Design and development of technical solution
- [x] Setup tech infrastructure  
- [x] Automated and acceptance tests  
  
**Stack**  
* .Net 6, Entity Framework
* xUnit, OpenAPI/Swagger, FluentValidator
* Docker, Git, Visual Studio 2022 
  
### How to Run  

* Execute `make api.publish` in the root folder

1) Local
* Launch the API in visual studio. 
* Navigate to `https://localhost:7001/_system/health`
* Navigate to `https://localhost:7001/swagger/index.html`

2) Local with docker
* (clear docker)
* Execute `make api.up`
* API - http://localhost:5001/_system/health
* API Swagger - `https://localhost:5001/swagger/index.html`

3) Run integration tests
* (clear docker)
* Execute `make integration-tests.up`

  
## Bonus Points  
- [x] Containerization - Docker 
- [x] Makefile
