# LIFProjet2020 JAAVOUE
**_Note: Ce projet utilise GitLFS, pour utiliser ce répertoire, il faut le pull en utilisant git et en ayant GitLFS d'installé localement_**

Ce répertoire contient le projet de l'UE [Lifprojet d'automne 2020](https://cazabetremy.fr/wiki/doku.php?id=projet:presentation) sujet AM3 

**Ce projet a été uniquement testé avec Windows (et n'est probablement pas compatible avec Linux en l'état car le Plugin Unity Open Pose est compilé pour Windows, il est peut-être possible d'utiliser le plugin avec Linux en le compilant vous même voir [ici](https://github.com/CMU-Perceptual-Computing-Lab/openpose_unity_plugin/blob/master/doc/installation.md#advanced-options) )**

Ce projet utilise Unity version `2020.2.1f1`

Ce projet est un jeu de course de bateau chronométré à la trackmania (mais avec un bateau (qui prend l'eau)) en utilisant les mouvements du corps à la kinect 


**Fonctionnalité du projet**
  * Utilise une reconnaisance de mouvement via Open Pose
  * Utilise le pipeline de rendu universel (URP) de Unity 
  * Contient un shader pour l'eau qui utilise Shader Graph
  * Les mouvements du bateau sont gérés à l'aide d'un script

#### Récupérer le projet (car c'est NOTRE PROJET)
En utilisant Git:
  1. S'assurer d'avoir GitLFS d'installé, voir [ici](https://git-lfs.github.com) pour plus de détails.
  2. Cloner le répertoire comme à l'habituel en utilisant un terminal/cmd ou votre logiciel graphique pour git favori.

#### Charger le projet:
Une fois que vous avez les fichiers du projet en local vous pouvez l'ouvrir en utilisant idéalement Unity version `2020.2.1f1` ou supérieure pour une meilleure expérience.

Une fois l'éditeur ouvert vous pouvez ouvrir la scène principale `Scenes/Main.unity`

**_Note: Les commits antérieurs au commit 139144c526b8a7a02d623c6b44c56eebc235c98d ont été fait sur Unity `2020.1.*`_**

**_Note: Charger le projet avec une version de Unity antérieur à `2020.2.*` (ex: `2020.1.*` ) en ayant le commit 139144c526b8a7a02d623c6b44c56eebc235c98d provoquera des erreurs de compilations_**

#### Build le projet:
Il est conseillé d'utiliser un dossier nommé `Build` pour stocker le build car celui-ci est déjà ignoré dans le .gitignore


# Notes

Assurez-vous de cloner le répertoire car en téléchargant le zip du répertoire, celui-ci ne contient pas les fichiers GitLFS (les textures et autres ...)   

# Licence 
Voir la [licence](LICENSE) 