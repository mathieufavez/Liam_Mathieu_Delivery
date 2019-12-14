SELECT DISTINCT TOP(2) Deliveryman.Id FROM ((Deliveryman
INNER JOIN Restaurant ON Deliveryman.FK_idCity=Restaurant.FK_idCity)
INNER JOIN Delivery ON Delivery.FK_idRestaurant=Restaurant.Id )
WHERE Deliveryman.FK_idCity=2 GROUP BY Deliveryman.Id HAVING COUNT(Delivery.status='A livrer') < 5









SELECT COUNT(status) FROM Delivery WHERE status='A livrer'




SELECT TOP(1) Deliveryman.Id FROM((Deliveryman
                                    INNER JOIN Restaurant ON Deliveryman.FK_idCity=@idCity)
                                    INNER JOIN Delivery ON @idRestaurant = Restaurant.Id) 
                                    GROUP BY Deliveryman.Id HAVING COUNT(Delivery.status) < 5


                                    SELECT Id, FK_idDeliveryman, FK_idRestaurant FROM Delivery GROUP BY Id,FK_idDeliveryman,FK_idRestaurant HAVING COUNT(status) < 5

