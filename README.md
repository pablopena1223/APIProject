# StudentDiscounts

This API is used to make the life of students easier. 
They can keep track of what services or subscriptions 
give student discoutns and choose to use them or not.
This includes the price,  the companys policy, and more. 

The following also applies to /api/student and api/company.


## API Reference

#### Get all services 

```http
  GET /api/service/

```
#### Get single service

```http
  GET /api/service/${id}
```

#### Post service

```http
  POST /api/service/
```

#### Delete service

```http
  DELETE /api/service/${id}
```
