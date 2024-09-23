VAR playerHaveBread = false

Привет, дорогая, чего тебе? #speaker: Мама #cooldown: 0,015
{playerHaveBread:
  +[Отдать хлеб] Арсений передал вам хлеб #speaker: Алие #anim: Talk
 Спасибо! Ты нас выручила #speaker: Мама
  -> END
 - else:
 +[Уйти] Ничего, просто хожу, осматриваюсь #speaker: Алие #anim: Talk
  Понятно, удачи#speaker: Мама
 -> END
}

