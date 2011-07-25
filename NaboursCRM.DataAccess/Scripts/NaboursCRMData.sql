insert into PhoneType (PhoneTypeId, PhoneType) values(1,'Home')
insert into PhoneType (PhoneTypeId, PhoneType) values(2,'Work')
insert into PhoneType (PhoneTypeId, PhoneType) values(3,'Cell')


SET IDENTITY_INSERT AddressType ON
insert into AddressType (AddressTypeId, AddressType) values(1, 'Mailing')
insert into AddressType (AddressTypeId, AddressType) values(2, 'Primary home')
insert into AddressType (AddressTypeId, AddressType) values(3, 'Work')
insert into AddressType (AddressTypeId, AddressType) values(4, 'Property')
SET IDENTITY_INSERT AddressType OFF
