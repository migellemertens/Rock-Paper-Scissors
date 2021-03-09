--------------------
ROCK PAPER SCISSORS 
--------------------
Development: Migelle Mertens
Design: Migelle Mertens

--------------------
1. SCORE CALCULATION
--------------------

1. Choices get assigned an Int value using an enum class
2. Int value of computerChoice gets % 3 calculation
3. Int value of userChoice and computerChoice get evaluated

--------------------
1.1 DRAW
--------------------
userChoice = Rock = Int value of 1
computerChoice = Rock = Int value of 1

userChoice = 1 % 3 = 1
computerChoice = 1 % 3 = 1

userChoice & computerChoice = same value using modulo = draw

--------------------
1.2 WIN
--------------------
userChoice = Paper = Int value of 2
computerChoice = Rock = int value of 1

userChoice = 2
computerChoice = 1 + 1

userChoice & computerChoice = same value using +1 = win

--------------------
1.3 LOSS
--------------------
If condition 1.1 and 1.2 are false = loss