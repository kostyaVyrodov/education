# CQRS

CQRS is command query responsibilities segregation. It's an architectural pattern separating commands and queries, e.g. reading and writing data.

**Commands** are the only way to change the state of our system. Commands shouldn't return value

**Queries** are read-only operations. They don't modify a state

## Applying CQRS

**Without CQRS**

`OrderingService`
```
void Ship(OrderId)
Order GetOrder(OrderId)
void ChangeOrderShipmentAddress(OrderId, NewAddress)
void CreateOrder(Order)
void ChangeOrderPaymentMethod(OrderId, PaymentMethod)
```

**With CQRS**

`OrderingWriteService`
```
void Ship(OrderId)
void ChangeOrderShipmentAddress(OrderId, NewAddress)
void CreateOrder(Order)
void ChangeOrderPaymentMethod(OrderId, PaymentMethod)
```

`OrderingReadService`
```
Order GetOrder(OrderId)
```

Sources: 

- [CQRS by example introduction](https://ilclubdellesei.blog/2018/11/02/cqrs-by-example-introduction/)
