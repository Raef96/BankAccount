# Bank Account Kata

## Directives

Ce kata est un challenge d'architecture hexagonale, il s'implémente par étape avec un **1er focus sur le domaine métier**.

Vos commits successifs dans Git retranscrivent vos étapes et le cycle TDD red/green/refactor si vous décidez de l'adopter. 

### Etape 1 - Le modèle métier

1ère étape est essentielle, vous vous concentrez sur le modèle métier : simple, efficace et non-anémique.

Vous l'isolez derrière les ports.

```
ATTENTION - CETTE PREMIERE ETAPE EST PRIMORDIALE
Elle devra être matérialisée proprement dans vos commits.
Elle est attendue par nos clients et ne devrait pas excéder 2h d'implémentation.
```

### Etape 2 - Adapteur API

Exposition des différentes fonctionnalités sur une API REST (Spring par ex.)

### Etape 3 - Adapteur de Persistence

Implémentation d'un adapteur de persistence de votre choix (SQLlite, H2, ...).

## User Stories
```
In order to implement this Kata, think of your personal bank account experience.
When in doubt, go for the simplest solution Requirements

* Deposit and Withdrawal
* Account statement (date, amount, balance)
* Statement printing
 

## User Story 1

In order to save money

As a bank client

I want to make a deposit in my account


## User Story 2

In order to retrieve some or all of my savings

As a bank client

I want to make a withdrawal from my account


## User Story 3

In order to check my operations

As a bank client

I want to see the history (operation, date, amount, balance) of my operations
```

## Credits
Merci aux craftsmen de la SGIB pour leurs exigences qui nous tirent vers le meilleur.
