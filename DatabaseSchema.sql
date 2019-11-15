CREATE TABLE Books (
	Id SERIAL UNIQUE,
	Title varchar NOT NULL,
	Author varchar NULL,
	ISBN nchar(14) NULL  -- ISBNs are 10 or 13 characters, but are sometimes written with a "-" after the first 3 digits so we allow 14 characters
);

CREATE TABLE Copies (
	Id SERIAL UNIQUE, -- This is used as the barcode, which will be printed and stuck on the book copy
	BookId int,
	Borrower varchar NULL, -- Only set if the book is borrowed
	DueDate timestamp NULL -- Only set if the book is borrowed
);

ALTER TABLE Copies ADD CONSTRAINT FK_Copies_Book FOREIGN KEY (BookId) REFERENCES Books (Id);