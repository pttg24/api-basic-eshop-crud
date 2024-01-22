SHELL = /bin/sh

api.publish:
	dotnet publish -c Release src/BasicEshopCrud.Api

api.up: api.publish
	docker compose -p basic-eshop-crud-api-only -f docker-compose.yml -f docker-compose.api.yml build --parallel && \
	docker compose -p basic-eshop-crud-api-only -f docker-compose.yml -f docker-compose.api.yml up -d

api.down:
	docker compose -p basic-eshop-crud-api-only down --remove-orphans

integration-tests.build:
	dotnet build -c Release test/BasicEshopCrud.Api.IntegrationTests

integration-tests.up: integration-tests.build api.publish
	docker compose -p basic-eshop-crud-api-int-tests -f docker-compose.yml -f docker-compose.api.yml -f docker-compose.integration-tests.yml build --parallel && \
	docker compose -p basic-eshop-crud-api-int-tests -f docker-compose.yml -f docker-compose.api.yml -f docker-compose.integration-tests.yml up --abort-on-container-exit --exit-code-from=integration-tests

integration-tests.down:
	docker compose -p basic-eshop-crud-api-int-tests down --remove-orphans
