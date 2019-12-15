SELECT DISTINCT TOP(1) Deliveryman.Id FROM ((Deliveryman INNER JOIN Restaurant ON Deliveryman.FK_idCity=Restaurant.FK_idCity) INNER JOIN Delivery ON Delivery.FK_idRestaurant=Restaurant.Id ) WHERE Deliveryman.FK_idCity=6 AND Delivery.status='A livrer' GROUP BY Deliveryman.Id HAVING COUNT(status) < 5


SELECT COUNT(status)



SELECT Id From Delivery WHERE status='A livrer' GROUP BY Id HAVING COUNT(status)<5


SELECT COUNT(status)>5 FROM Delivery WHERE FK_idDeliveryman = 3 




SELECT TOP(1) Deliveryman.Id FROM((Deliveryman
                                    INNER JOIN Restaurant ON Deliveryman.FK_idCity=2)
                                    INNER JOIN Delivery ON Delivery.FK_idRestaurant = 1) 
                                    GROUP BY Deliveryman.Id HAVING COUNT(Delivery.status) < 10


                                    SELECT Id, FK_idDeliveryman, FK_idRestaurant FROM Delivery GROUP BY Id,FK_idDeliveryman,FK_idRestaurant HAVING COUNT(status) < 5

