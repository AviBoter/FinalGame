# LiadBabies

## Game description:

The game is about group of baby dragons who try to push you out of the road to be considered the king of babies.
try reach the christmas tree to win the game, Have Fun!

## Scripts:

**movement**:

- TouchDetector.cs - This component checks whether its object touches a collider of a given kind [Link](https://github.com/Lba-universe/PathsToA/blob/master/Assets/Scripts/Collisions/TouchDetector.cs)
- Movement.cs - This component is for moving, jump, dash the charcther by his rigidbody
  also using touchDetector to achive jump ability by knowing when he is on the ground [Link](https://github.com/Lba-universe/PathsToA/blob/master/Assets/Scripts/Movers/Movement.cs)
- LookX.cs - This component rotates its object according to the mouse movement in the X axis [Link](https://github.com/Lba-universe/PathsToA/blob/master/Assets/Scripts/Movers/LookX.cs)
- LookY.cs - This component rotates its object according to the mouse movement in the Y axis [Link](https://github.com/Lba-universe/PathsToA/blob/master/Assets/Scripts/Movers/LookY.cs)
- CursorHider.cs - This component lets the player show/hide the cursor by clicking ESC. [Link](https://github.com/Lba-universe/PathsToA/blob/master/Assets/Scripts/Movers/CursorHider.cs)

**Attacks**:

- CustomProjectiles.cs - This component Instantiate new explosion Check for enemies and push them [Link](https://github.com/Lba-universe/PathsToA/edit/master/Assets/Scripts/Collisions/CustomProjectiles.cs)
- PushForce.cs - This component pushes all the enemies that get with this game object to collision
  [Link](https://github.com/Lba-universe/PathsToA/blob/master/Assets/Scripts/Attacks/PushForce.cs)
- kickHim.cs -
  This component represent a kick abillty that push enemies away using raycast [Link](https://github.com/Lba-universe/PathsToA/blob/master/Assets/Scripts/Attacks/kickHim.cs)

**AI**:
**old version**

- AIController.cs - this is script represent AI controller include 3 behaviors of AI patrol , Chase and Shot/Attack [Link](https://github.com/Lba-universe/PathsToA/blob/master/Assets/Scripts/AI/AIController.cs)

**new version**

- IBehaviorAI.cs - Interface from AI behaviors [Link](https://github.com/Lba-universe/PathsToA/blob/master/Assets/Scripts/AI/IBehaviorAI.cs)
- PatrolingBehaviorAI.cs - this script is representing a AI patrol behaviour by using raycast and given layer generate walk points and set it to the nav mash agent [Link](https://github.com/Lba-universe/PathsToA/blob/master/Assets/Scripts/AI/PatrolingBehaviorAI.cs)
- ChaserBehaviorAI.cs - this script is representing a AI Chaser behavior, using navmesh agent to set destintaion on player position [Link](https://github.com/Lba-universe/PathsToA/blob/master/Assets/Scripts/AI/ChaserBehaviorAI.cs)
- ShootBehaviorAI.cs - this script is representing a AI Shoot behavior that instantiate attack on player by given projectile to throw [Link](https://github.com/Lba-universe/PathsToA/blob/master/Assets/Scripts/AI/ShootBehaviorAI.cs)
- BehaviorAIController.cs - this is script represent AI controller include 3 behaviors of AI patrol , Chase and Shot/Attack [Link](https://github.com/Lba-universe/PathsToA/blob/master/Assets/Scripts/AI/BehaviorAIController.cs)

## Animations:

we take the baby from https://sketchfab.com/

credit:
"Baby" by beetseric is licensed under Creative Commons Attribution.
https://skfb.ly/n5lk4hcb To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/.

and add animation from https://www.mixamo.com/

anime script :[movingAnime.cs](https://github.com/Lba-universe/PathsToA/blob/master/Assets/Scripts/animeScript/movingAnime.cs)

## Pics

![](https://github.com/Lba-universe/PathsToA/blob/master/pics/Screenshot%202020-12-29%20062337.png)

![](https://github.com/Lba-universe/PathsToA/blob/master/pics/Screenshot%202020-12-29%20062446.png)

![](https://github.com/Lba-universe/PathsToA/blob/master/pics/pics1.png)

## Credits

Unity Particle Pack 5.x - [Link](https://assetstore.unity.com/packages/essentials/asset-packs/unity-particle-pack-5-x-73777)

FREE Christmas Assets/Low Poly by BRAINBoX [Link](https://assetstore.unity.com/packages/3d/props/free-christmas-assets-low-poly-13102)

Music: "Positive" Happy Hip Hop Beat Rap Instrumental (Prod. Ihaksi).

<div dir='rtl' lang='he'>
  
  
# LiadBabies
---

**תיאור המשחק : המשחק הוא על קבוצת תינוקות אשר מנסים לדחוף אחד את השני מהזירה כדי להיחשב מלך התינוקות, במחשק יש שלבים כך שכל שלב הרמה קשה יותר ובנוסף יש אופציה לרב משתתפים**

## מהות המשחק

אחרי יום עבודה מתיש, או יום לא פשוט, זמן שרוף בשירותים
כל מה שבא לך לעשות זה להירגע ולנוח בלי יותר מידי מחשבה, אין דרך יותר
נוחה מזה מאשר לשחק בליעד בייביס.
משחק שבו המטרה כמה תינוקות דוחפים אחד את השני והמטרה היא להישאר האחרון שבזירה.

- המשחק הוא משחק אינטרנטי דורש מחשב רגיל (צוות המפתחים שלנו עובד על גרסת המובייל)
- מיועד לכל הגילאים ולכל המינים
- במשחק תוכלו לשחק גם בגרסת השלבים וגם ברב משחתתפים , מאותו מחשב או באינטרנט

---

## פרטי המשחק

### 1. מה רואים?

- המשחק הוא משחר תלת מימד
- בכל שלב יש מפה מרחפת אשר ברגע שנופלים ממנה מפסידים
- אי אפשר לצאת מגבולות המפה
- מעבר רואים כל מיני עננים ותפאורה בהתאם לשלב

### 2. מה עושים?

- בתחילת המשחק כל השחקנים מופיעים על המפה ויוצאים לדרך לנסות ולהפיל את האחרים
- תהליך הליבה- השחקן יכול לנוע בחופשיות במפה וגם לקפוץ ולנסות ולדחות את היריבים בעזרת מתקפות
- כדי לסיים את המשחק חייב השחקן להביס את כל השאר ולהישאר אחרון בזירה
- השחקן ישתמש במקשי המקלדת

### 3. מה העצמים?

קיימים כמה אוביקטים במשחק

- השחקנים שהם בצורת תינוקות
- המפה המרחפת
- קיימים עוד כמה עצמים שהם מהווים מכשולים
- בנוסף קיים למטה גבול שברגע שאחד השחקנים נוגע בו הוא נהרס

### 4. מה האפשרויות?

- במשחק קיימים 30 שלבים, בבכל שלב רמת הקושי עולה
- כל סוגי השחקנים יהיו דמיות של תינוקות אך מגוונים בנראות
- כל שחקן יוכל לבחור דמות שהוא אהב

### 5. מה העולם?

- העולם הוא עולם סגור כי ברגע שנופלים מגבולות המפה נגמר השלב ומתחילים שוב
- העולם עולם פיזיקלי כך שכל השחקנים מושפעים מכוחות הטבע והפיזיקה

### 6. מה הסיפור?

הרקע למשחק: לפני הרבה הרבה שנים בן אדם לא היו מתבגרים , וגם לא קראו להם בני אדם , אלא
תינוקות . בממלכת התינוקות שבגן העדן הם חיו באושר ועושר ומקיימים אורך חיים רגיל של תינוקות
אבל עם מודעות של מבוגרים, עד שיום אחד החליט מלך הדרקונים הכחולים שהוא רוצה לבטל את שירותי
החסידות , החסידות הם אלא שהביאו את התינוקות לעולם.
והוא החליט לערוך קרב תינוקות ראש מסוגו שבו כל תינוק מייצג את ספקית התינוקות החדשה
וכך התינוק התחיל את מסעו ונולדה לה היסטוריה

### 7. מי הדמויות?

- הדמויות יהיו כמו ינוקות אשר להם יש יכולות תקיפה מצחיקות ומגוונות
- הגיבור יהיה השחקן שהוא תפקידו להישאר אחרון בזירה
- יהיו עוד דמויות משניות כגון דרקונים כחולים וירוקים שינסו להעיף את התינוק שלנו

## שלבים במשחק

- שלב ראשון זירה רגילה וכולם על כולם
- שלב שני קרב אחד על אחד באל עם מכשולים של אש
- שלב שלישי יותר אויבים ומפה אחרת
- שלב רביעי מלא נלא אויבים שרודפים אחריך ומפה אחרת
- שלב חמישי בבנייה

---

## סקר שוק

בבדיקה חיפוש באינטרנט , המשחקים קלילים, שלא דורשים יותר מידי חשיבה והתעסקות
רק לשחק ולהנות ,זה מה שמוכר, ניתן לראות לפי אתר הסטרימינג הגדול שיש ביקוש
למשחקים כאלו.
מבחינת דמיון למשחקים אחרים, לא קיים דמיון לדמויות המרכזיות שלנו תינוקות ועם יכולת
אחת ובודדת דחיפה פשוטה, בנוסף אנחנו מעוניינים להוסיף סיבובים שיכללו משימות כגון
לגנוב את הדגל וכו

</div>