# B_Dig_Ns_2 project 

OOP pielietošana:

Mantošana:
Character — bāzes klase. 
Player : Character.
Enemy : Character.
+ Berserker : Enemy.
UN
Weapon — bāzes klase.
BasicWeapon : Weapon.
PoisonWeapon : Weapon.

Polimorfisms:
public override int Attack() - klasē Berserker.
Overload (metodes pārslodze):
TakeDamage(int damage).
TakeDamage(Weapon weapon).

Enkapsulācija:
Character.cs - enkapsulēts lauks Health (getter un setter).

Abstrakcija:
Weapon — abstrakta klase 
GetDamage() — parasta metode 
ApllyEffect() — abstrakta metode 
BasicWeapon, PoisonWeapon — manto no Weapon. 




Papilduzdevumi:

Spēlētājam ir trīs varianti ar attack:
Attack1 - randomly ņem nost dzīvības (1-7 hp).
Attack2 - 1.5x no parastā, atdzišana - 2 gājieni. 
Attack3 - 2x no parastā, Spēlētājs vēl zaudē 2 hp.

Ir vairogs - vairogu var ieslēgt, bet viņš nostrādā tikai trīs raundus un tad vēl trīs raundus viņu nav iespējams izmantot.
Un heal poga - viņu var izmantot tikai vienu reizi, vairogs dod +50 hp, taču ja jūsu health ir lielāks nekā 50, tad viņš vienkārši dos dzīvības līdz 100, ne vairāk (100 ir maksimums).

Sound efekti:
Attack pogām viens Sound efekts, Heal pogai cits un Shield pogai cits. Arī ir background mūzika un zaudēšanas loga sound.

Enemy:
Spēlētājam ir 100 hp. Pretinieku ir divi veidi, kad enemy (20 hp) ar parasto ieroci un berserkers (30 hp) ar poison ieroci. Kad viens nomirst, parādās randomly viens no tiem pretiniekiem. Kad nomirst spēlētājs, tad parādās logs "YOU DIED" un iespēja restartēt spēli. 

