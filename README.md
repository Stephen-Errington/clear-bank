### Notes
I've left two account data stores in but depending on what these are e.g. both SQL - you could inject the different connection string when opening the connection and have the one store.

Balance deduction is hard to unit test in its current form so would either need an integration test using something like SpecFlow or move the code to a method on AccountService.

I've added a unit test to check that each payment scheme has a validator - These tests would be ran in a pipeline and fail deployment if any failed.
