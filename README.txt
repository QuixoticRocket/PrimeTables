Look at the requirements ad get an idea of what project setup we will require.
We will need a test project.
We will use a console app as the display layer for capturing input and displaying output. This can be switched to another display layer at a later point, maybe.
All our logic is likely to reside in the PrimeNumberLogic layer.
There is no data access and so no seperate layer is required for that.
In a larger project I would have a seperate "Shared" project for holding interfaces and DTOs and "global" utility items, but on such a small, focused project it doesn't make sense.
---
Classes:
Normally I'd approach this sort of problem by using a factory to set up an object that would then be called to do the processing, but there is no real set up required here so we will forgo the factory.
There should be a class that generates prime numbers. That is it's focus and it can remain internal to PrimeNumberLogic. -PrimeNumberGenerator - internal, interfaced
There will need to be a class to build the multiplication table. It doesn't really care what numbers it uses and so shouldn't rely on prime numbers. -TableGenerator - internal
We can have a controller that takes a number generator (interfaced. in this case it'll generate primes) and gives it to the table generator along with N, and return the result. -PrimeNumberEngine public

We want to use dependancy injection as much as possible. It may be overkill on such a small project especially when all the logic is in one dll. 
I was going thinking of interfacing the tablegenerator class too so that we could switch the type of table generated, but since this is all internal and the engine is making the decisions here it seemed like overkill.
The engine will be interfaced since it is a public facing entrypoint to the dll.

In theory we shouldn't really interface the prime number generator as it is internal, 
but if we wanted to have multiple number generation sources then we would split this off to its own dll and swap in the required generators as required. 
This is where the factory pattern would be great, taking the numbergenerator (and maybe table generator if we interfaced and split it) you want and returning an engine which is then used to do the processing.

---
Tests:
We will use Moq framework here. this means we may need to make some classes virtual if they're not interfaced, but since this should only be internal classes we shoudl still control any inheritance.
We will need to expose internal methods to the appropriate assemblies for testing.

---