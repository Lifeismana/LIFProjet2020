# LIFProjet2020 JAAVOUE
**_Note:Ce projet utilise GitLFS, pour utiliser ce répertoire, il faut le pull en utilisant git et en ayant GitLFS d'installé localement_**

Ce répertoire contient le projet de l'UE [Lifprojet d'automne 2020](https://cazabetremy.fr/wiki/doku.php?id=projet:presentation) sujet AM3 

**Ce projet a été uniquement testé avec Windows (et n'est probablement pas compatible avec linux en l'état car le Plugin unity open pose est compilé pour windows, il est peut-être possible d'utiliser le plugin avec linux en le compilant vous même voir [ici](https://github.com/CMU-Perceptual-Computing-Lab/openpose_unity_plugin/blob/master/doc/installation.md#advanced-options) )  **
Ce projet utilise unity version `2020.2.1f1`

Ce projet est un jeu de course de bateau chronométré à la trackmania (mais avec un bateau (qui prends l'eau)) en utilisant les mouvement du corps à la kinect 



**Fonctionnalité du projet**
  * Utilise .....
  * Utilise le pipeline de rendu universel (URP) de Unity 
  * Contient un shader pour l'eau qui utilise Shader Graph
  * Les mouvement du bateau sont gérer à l'aide d'un script

#### Récupérer le projet (car c'est NOTRE PROJET)
En utilisant Git:
  1. S'assurer d'avoir GitLFS d'installé, voir [ici](https://git-lfs.github.com) pour plus de détails.
  2. Cloner le répertoire comme à l'habituel en utilisant un terminal/cmd ou votre logiciel graphique pour git favori.

#### Ouvrir (Charger ?) le projet:
Une fois que vous avez les fichiers du projet en local vous pouvez l'ouvrir (Charger ?) en utilisant idéalement Unity version `2020.2.1f1` ou supérieur pour une meilleure expérience.
Upon loading the project will display a small welcome screen with some buttons to load starting scenes.
**_Note:Les commits antérieur au commit `9d877d1485acb5b25610166e33c90228e206eafd`ont été fait sur unity `2020.1.*`_**
**_Note:Charger le projet avec Unity `2020.1.*` en ayant le commit `9d877d1485acb5b25610166e33c90228e206eafd` provoquera des erreurs de compilations _**

Une fois l'éditeur ouvert vous pouvez ouvrir la scène principale `Scenes/Main.unity`

#### Build le projet:
Il est conseillé d'utiliser un dossier nommé `Build` pour stocker le build car celui-ci est déjà ignoré dans le .gitignore


# Notes

*Assurez-vous de cloner le répertoire car sinon en téléchargant le zip du répertoire, celui-ci ne contient pas les fichiers GitLFS (les textures et autres ...)   

# License 
Voir la [license](LICENSE) 