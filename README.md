# Rest is...

- REST is an architectural style, not an standard
- We use standards to implement this architectural style
- REST is protocol agnostic

## Learning what the REST constraints are about

- REST is defined by 6 constraints (one optional)
- A constraint is a design decision that can have positive and negative impacts

### Uniform Interface

API and consumers share one single, technical interface: URI, Method, Media Type (payload)

### Client-Server

Client and server are separated (client and server can evolve separately)

### Statelesness

State is contained within the request

### Layered System

Client cannot tell what layers it's connected to

### Cacheable

Each response message must explicity state if it can be cached or not

### Code on Demand (optional)

Server can extend client functionality

> A System is only considered RESTfull when it adheres to all the required constraints.  
> Most "RESTful" APIs aren't really RESTful...  
> ... but that doesn't make them bad APIs, as long as you understand the potential trade-offs

## The Richardson Maturity Model

## Level 0 (The Swamp of POX)

HTTP protocol is used for remote interaction  
... the rest of the protocol ins't used as it should be  
RPC-style implementations (SOAP, often seen when using WCF)

> POST (info on data)  
> http://host/myapi
>
> POST (author to create)  
> http://host/myapi

## Level 1 (Resources)

Each resources is mapped to URI  
HTTP methods aren't used as they should be  
Results in reduced complexity

Only one http method (POST) is still used for interaction

> POST  
> http://host/api/authors
>
> POST  
> http://host/api/authors/{id}

## Level 2 (Verbs)

Correct HTTP verbs are used  
Correct status codes are used

Removes unnecessary variation

> GET  
> http://host/api/authors  
> 200 OK (authors)
>
> POST (author representation)  
> http://host/api/authors  
> 201 Created (author)

## Level 3 (Hypermedia)

The API supports Hypermedia as the Engine of Application State (HATEOAS)

Introduces discoverability

> GET  
> http://host/api/authors  
> 200 ok (authors + links that drive application state)

**Leve 3 is a precondition for a RESTful API**

## Resource Naming Guidelines

Nouns: things, not actions. Action is the HTTP method.

- (BAD) api/getauthors
- (GOOD) GET api/authors
- (GOOD) GET api/authors/{authorId}

Follow through on this principle for predictability

- (BAD) api/something/somethingelse/employees
- (GOOD) api/employees
- (BAD) api/id/employees
- (GOOD) api/employees/{employeeId}

Represent hierarchy when naming resources

- (GOOD) api/authors/{authorId}/courses
- (GOOD) api/authors/{authorId}/courses/{coursesId}

Filters, sorting orders, ... aren't resources

- (BAD) api/authors/orderby/name
- (GOOD) api/authors?orderby=name

Sometimes, RPC-style calls don't easily map to pluralized resource names

- (BAD) api/authors/{authorId}/pagetotals
- (BAD) api/authorpagetotals/{id}
- (GOOD) api/authors/{authorId}/totalamountofpages (exception case)

## The importance of status codes

Status codes tell the consumer of the API

- Whether or not the requeust worked out as expected
- What is responsible for a failed request

### Level 200 - Success

- 200 - Ok
- 201 - Created
- 204 - No content. Eg: for deletes.

### Level 300

Those are used for redirections, most API's don't need these

### Level 400 - Client Mistakes

- 400 - Bad request. Eg: JSON provided cannot be parsed.
- 401 - Unauthorized. Eg: No or invalid authentication were provided.
- 403 - Forbidden. Eg: Authentication succedded but the authenticated user doesn't have access to the resource.
- 404 - Not found. Requested resources doesn't exist.
- 405 - Method not allowed. Happens when we try to send a request to a resource with a HTTP method not allowed.
- 406 - Not acceptable.
- 409 - Conflict. Can be used when we try to create a resource that already exists.
- 415 - Unssuported media type.
- 422 - Unprocessable entity. Can be used when a validation rule fails.

### Level 500 - Server Mistakes

- 500 - Internal server error

## Errors vs Faults

### Errors

Consumer passes invalid data to the API, and the API correctly rejects this

Level 400 status codes  
Do not contribute to API availability

### Faults

API fails to return a response to a valid request

Level 500 status codes  
Do contribute to API availability

## Content Negotiation

The process of selecting the best representation for a given response when there are multiples representations available. This is done via the `Accept` header.

> Eg:  
> Accept: application/json  
> Accept: application/xml
