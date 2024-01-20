Feature: Basic Eshop management

  Scenario: Create a new customer
    Given a customer request is created
    When the POST request is sent to the api
    Then the response status code should be 201
    And the response should contain a created customer fully populated

  Scenario: Get an existing customer by ID
    Given a customer request is created
    When the POST request is sent to the api
    Then the response status code should be 201
    When the GET request is sent to the api with the created customer details
    Then the response status code should be 200
    And the response should contain a created customer fully populated

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
    When I send a POST request to "/api/products" with the following data:
      | Name     | Description     | SKU        |
      | Product1 | Description1    | SKU123     |
    Then the response status code should be 201
    And the response should contain a created product with the following data:
      | Name     | Description     | SKU        |

  Scenario: Get an existing product by ID
    Given there is an existing product with ID 1
    When I send a GET request to "/api/products/1"
    Then the response status code should be 200
    And the response should contain the product with the following data:
      | Name     | Description     | SKU        |

  Scenario: Update an existing product
    Given there is an existing product with ID 1
    When I send a PUT request to "/api/products/1" with the following data:
      | Name         | Description         | SKU          |
      | UpdatedName  | UpdatedDescription  | UpdatedSKU   |
    Then the response status code should be 200
    And the response should contain the updated product with the following data:
      | Name         | Description         | SKU          |

  Scenario: Delete an existing product
    Given there is an existing product with ID 1
    When I send a DELETE request to "/api/products/1"
    Then the response status code should be 204
    And the product with ID 1 should no longer exist

  Scenario: Create a new order
    Given there is an existing customer with ID 1
    And there is an existing product with ID 1
    When I send a POST request to "/api/orders" with the following data:
      | CustomerId | ProductId | Status   |
      | 1          | 1         | Pending  |
    Then the response status code should be 201
    And the response should contain a created order with the following data:
      | CustomerId | ProductId | Status   |

  Scenario: Get an existing order by ID
    Given there is an existing order with ID 1
    When I send a GET request to "/api/orders/1"
    Then the response status code should be 200
    And the response should contain the order with the following data:
      | CustomerId | ProductId | Status   |

  Scenario: Update an existing order
    Given there is an existing order with ID 1
    When I send a PUT request to "/api/orders/1" with the following data:
      | CustomerId | ProductId | Status   |
      | 1          | 1         | Shipped  |
    Then the response status code should be 200
    And the response should contain the updated order with the following data:
      | CustomerId | ProductId | Status   |

  Scenario: Delete an existing order
    Given there is an existing order with ID 1
    When I send a DELETE request to "/api/orders/1"
    Then the response status code should be 204
    And the order with ID 1 should no longer exist