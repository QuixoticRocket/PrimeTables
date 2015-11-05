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

answer array example for pattern (not using primes)

 | 2 | 3 | 4 | 5 | 7 |
2  4   6   8  10  14
3  6   9  12  15  21  
4  8  12  16  20  28
5 10  15  20  25  35
7 14  21  28  35  49

---
REFACTORING:
Thinking about how I could make the prime number generation faster, I see that my approach is somewhat similar to the Sieve of Eratosthenes.
https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes - lovely animated gif showing how it works.
There are a few other sieves and various methods for producing large primes. Once we get to a certain point we will need to return longs and not ints.
Even returning uints would increase our range slightly.
But i've tested my code with 1000 primes and it is responsive and does not crash.
However we could do some unchecked assignment and then test for overflow to see if we've gone past our limit.
These are just some ideas if we were to move forward.