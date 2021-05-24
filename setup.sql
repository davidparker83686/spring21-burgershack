CREATE TABLE accounts(
   id VARCHAR(255) NOT NULL,
   name VARCHAR(255) NOT NULL,
   email VARCHAR(255) NOT NULL,
   picture VARCHAR(255) NOT NULL,
   PRIMARY KEY (id)
);

CREATE TABLE burgers(
   id INT NOT NULL AUTO_INCREMENT,
   creatorId VARCHAR(255) NOT NULL,
   name VARCHAR(255) NOT NULL,
   cost INT NOT NULL,
   quantity INT NOT NULL,
   modifications  VARCHAR(255) NOT NULL,


   PRIMARY KEY (id),
   FOREIGN KEY(creatorId)
   REFERENCES accounts(id)
   ON DELETE CASCADE
 );

CREATE TABLE drinks(
   id INT NOT NULL AUTO_INCREMENT,
   creatorId VARCHAR(255) NOT NULL,
   name VARCHAR(255) NOT NULL,
   cost INT NOT NULL,
   quantity INT NOT NULL,
   modifications  VARCHAR(255) NOT NULL,


   PRIMARY KEY (id),
   FOREIGN KEY(creatorId)
   REFERENCES accounts(id)
   ON DELETE CASCADE
 );
 
CREATE TABLE sides(
   id INT NOT NULL AUTO_INCREMENT,
   creatorId VARCHAR(255) NOT NULL,
   name VARCHAR(255) NOT NULL,
   cost INT NOT NULL,
   quantity INT NOT NULL,
   modifications  VARCHAR(255) NOT NULL,


   PRIMARY KEY (id),
   FOREIGN KEY(creatorId)
   REFERENCES accounts(id)
   ON DELETE CASCADE
 );








