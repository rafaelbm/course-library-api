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

>POST (info on data)  
>http://host/myapi  
>
>POST (author to create)  
>http://host/myapi

##  Level 1 (Resources)

Each resources is mapped to URI  
HTTP methods aren't used as they should be   
Results in reduced complexity

Only one http method (POST) is still used for interaction

>POST  
>http://host/api/authors
>
>POST  
>http://host/api/authors/{id}

## Level 2 (Verbs)

Correct HTTP verbs are used  
Correct status codes are used

Removes unnecessary variation

>GET  
>http://host/api/authors   
>200 OK (authors)
>
>POST (author representation)   
>http://host/api/authors  
>201 Created (author)

## Level 3 (Hypermedia)

The API supports Hypermedia as the Engine of Application State (HATEOAS)

Introduces discoverability

>GET  
>http://host/api/authors  
>200 ok (authors + links that drive application state)

**Leve 3 is a precondition for a RESTful API**