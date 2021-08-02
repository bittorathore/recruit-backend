## Specification
- One operation to store the input data
- One operation to query all data that has been stored
- One operation to query one of the input data stored

## ToRun
- Please Run migrations first using below commands in package manager
    - update-database -context DatabaseContext
    - update-database -context ApplicationDbContext
    - You will need to create a user using Register User endpoint
    - User will manually have to generate data in the system
    - DataBase Seeding script & Integration Tests are missing, I will add get them if i get time today.
