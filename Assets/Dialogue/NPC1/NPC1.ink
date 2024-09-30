VAR isGaveBread = true
-> start

=== start ===
Привет, меня зовут Арсений. #speaker: Арсений #cooldown: 0,015

*[Поздороваться] Привет, а меня Алие. #speaker: Алие #anim: Talk
    -> Question

-> END

=== Question ===
+ [узнать возраст] А сколько тебе лет? #speaker: Алие #anim: Talk
    Мне вот-вот исполнится 13. #speaker: Арсений
    -> Question

+ [Помочь] Тебе с чем-нибудь помочь? #speaker: Алие #anim: Talk
    {isGaveBread:
    Нет, ты уже сделала, достаточно. #speaker: Арсений
    -> Question
- else:
Отнесешь маме хлеб? #speaker: Арсений
+ Да, конечно. #speaker: Алие #anim: Talk #variableChange: isGaveBread = true
         ~ isGaveBread = true
        Спасибо большое! #speaker: Арсений #item: bread
        -> Question
+ Нет. #speaker: Алие #anim: Talk
        Ладно, сам справлюсь. #speaker: Арсений
        -> Question
}

*[Уйти] Мне пора идти. #speaker: Алие #anim: Talk
    Пока-пока! #speaker: Арсений
    -> END
