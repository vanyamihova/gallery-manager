Prepare the database first:

```
CREATE TABLE Gallery
(
    Id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Label varchar(255)
);
```

```
CREATE TABLE Image
(
    Id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Label varchar(30),
    Filename varchar(255),
    GalleryId int,
    FOREIGN KEY(GalleryId) REFERENCES Gallery(Id) ON DELETE CASCADE
);
```


