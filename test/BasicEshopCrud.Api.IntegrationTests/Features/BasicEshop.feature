Feature: Basic Eshop management

  Scenario: Create a new customer
    Given a customer request is created
    When the POST request is sent to the api
    Then the response status code should be 201

  Scenario: Get an existing customer by ID
    Given a customer request is created
    When the POST request is sent to the api
    Then the response status code should be 201
    When the GET request is sent to the api with the created customer details
    Then the response status code should be 200
    And the GET response should contain a created customer fully populated

  Scenario: Update an existing customer
    Given a customer request is created
    When the POST request is sent to the api
    Then the response status code should be 201
    When the PUT request is sent to the api with new customer details
    Then the response status code should be 200
    And the response should contain the updated customer fully populated

  Scenario: Delete an existing customer
    Given a customer request is created
    When the POST request is sent to the api
    Then the response status code should be 201
    When the DELETE request is sent to the api with the created customer details
    Then the response status code should be 204
    And the customer should no longer exist

  Scenario: Create a new product
    Given a product request is created
    When the POST request is sent to the api
    Then the response status code should be 201

  Scenario: Get an existing product by ID
    Given a product request is created
    When the POST request is sent to the api
    Then the response status code should be 201
    When the GET request is sent to the api with the created product details
    Then the response status code should be 200
    And the GET response should contain a created product fully populated

  Scenario: Update an existing product
    Given a product request is created
    When the POST request is sent to the api
    Then the response status code should be 201
    When the PUT request is sent to the api with new product details
    Then the response status code should be 200
    And the response should contain the updated product fully populated

  Scenario: Delete an existing product
    Given a product request is created
    When the POST request is sent to the api
    Then the response status code should be 201
    When the DELETE request is sent to the api with the created product details
    Then the response status code should be 204
    And the product should no longer exist

  Scenario: Create a new order
    Given a order request is created
    When the POST request is sent to the api
    Then the response status code should be 201

  Scenario: Get an existing order by ID
    Given a order request is created
    When the POST request is sent to the api
    Then the response status code should be 201
    When the GET request is sent to the api with the created order details
    Then the response status code should be 200
    And the GET response should contain a created order fully populated

  Scenario: Update an existing order
    Given a order request is created
    When the POST request is sent to the api
    Then the response status code should be 201
    When the PUT request is sent to the api with new order details
    Then the response status code should be 200
    And the response should contain the updated order fully populated

  Scenario: Delete an existing order
    Given a order request is created
    When the POST request is sent to the api
    Then the response status code should be 201
    When the DELETE request is sent to the api with the created order details
    Then the response status code should be 204
    And the order should no longer exist