# Hobby Animals Care

## By: Nicolas Nino Lozano - A0T4ZR

### Task Description

Hobby animals need several things to preserve their exhilaration. Steve has some hobby animals
> Tarantulas,
>Hamsters
>Cats
Every animal has a name and their exhilaration level is between 0 and 70 (0 means that the
animal is  dead). If their keeper is joyful, he takes care of everything to cheer up his animals, and their exhilaration level increases this way:
>Tarantulas by 1  
>Hamsters by 2
>Cats by 3.
On a usual day, Steve takes care of only the cats (their exhilaration level increases by 3), so the exhilaration level of the rest decreases this way:
>Tarantulas by 2  
>Hamsters by 3
On a blue day, every animal becomes a bit sadder and their exhilaration level decreases this way:
>Tarantulas by 3  
>Hamsters by 5
>Cats by 7.
Steve’s mood improves by one if the exhilaration level of every alive animal is at least 5.
Every data is stored in a text file. The first line contains the number of animals. Each of the following lines contain the data of one animal: one character for the type (T – Tarantula, H – Hamster, C – Cat), name of the animal (one word), and the initial level of exhilaration.
In the last line, the daily moods of Steve are enumerated by a list of characters (j – joyful, u – usual, b – blue). The file is assumed to be correct.

List the animals of the highest exhilaration level at the end of each day

### Input Data

The data is stored in a text file with the following format:

- The first line contains the number of animals.
- Each subsequent line contains data for one animal, including its type (T for Tarantula, H for Hamster, C for Cat), name, and initial excitement level.
- The last line contains Steve's daily moods represented by a list of characters (j for joyful, u for usual, and b for blue).

**A possible input file:**
3
T Webster 20
H Butterscotch 30
C Cat-man-do 50
uuuujjbjbjuujj