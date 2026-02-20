### Comment est formatée ma DB et pourquoi je l'ai choisie comme ça ?



###### J'ai décidé de partir sur une seule table car elle est plus simple à mettre en place rapidement pour prototyper l'application demandée lors de l'exercice, la table est composée de 5 colonnes Id, Email, Is\_News, Is\_Monthly et IsDayFact.

###### 

###### J'ai également choisi de rajouter un index pour l'email même si au final je ne l'utilise pas ici mais j'aurais pu en faire une route dans l'api afin de chercher par email facilement.

###### 

###### Cette mise en place m'a permis d'avoir une implémentation simple et rapide, d'un Id auto-incrémentée, une adresse email ( dont le format est vérifié qu'elle correspond au format email ) et de trois valeurs booléenne pour les types d'abonnement.

###### 

###### Je pensais partir à la base sur trois tables, une pour la personne s'enregistrant à la newsletter, une pour les différentes newsletter et une many-to-many afin de faire les relations mais ceci me semblait plus compliqué à mettre en place dans le temps imparti pour un prototype.





### **Que font les routes mise en place ?** 



###### J'ai mis en place 4 routes dans mon controller,

###### 

###### \- Une "GetById" en \[HttpGet] afin de pouvoir retrouver une entrée facilement, j'aurais pu mettre en place un par email mais j'ai préféré rester simple pour tester le prototype au mieux possible.

###### 

###### \- Une route "AddElement" en \[HttpPost] pour ajouter un élément dans la newsletter, celle-ci va aller exploiter les méthodes internes au service afin d'envoyer également le mail lors du "Create()".

###### 

###### \- Une route "Delete" en \[HttpDelete] afin de supprimer une entrée si l'utilisateur choisi de se désabonner à la newsletter, celle-ci va également exploiter les méthodes internes du service afin d'envoyer un mail de confirmation à la désincription lors du "Delete()".

###### 

###### \- Une route "UpdateSub" en \[HttpPatch] afin de pouvoir mettre à jours ses souscription à la newsletter, celle-ci va aussi exploiter les méthodes internes du service afin d'envoyer un mail de confirmation que les changements ont bien été pris en compte lors du "UpdateNewsChoice()".

###### 

###### Les méthodes du service sont celle du "NewsletterService".

