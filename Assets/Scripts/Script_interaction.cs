using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Script_interaction : MonoBehaviour
{   
    public SpriteRenderer fader_renderer;
    protected float current_alpha = 0;
    public Script_text scriptSur;
    public GameObject joueur;
    public string sentence;
    protected bool isInteracting = false;
    protected bool isInteractingDesktop = false;
    protected float timeBeforeNextInteraction = 1f;
    public GameObject regieOuverte;
    public GameObject regieFermer;
    public bool firstTeleport = false;
    public bool firstSentenceInLoge1 = false;
    public bool firstTimeInLoge1 = true;
    public bool firstTimeInLoge2 = true;
    public bool firstTimeInAScene = true;
    public Script_Casier scriptCasier;
    public int etape = 0;
    protected string activeScene = "";

    public Script_DisplayTexte scriptDisplayTexte;

    public bool isInFinalChoice = false;

    public float triggerDistance = 5.0f;
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        if (isInteracting)
        {
            timeBeforeNextInteraction -= Time.deltaTime;
        }
        else
        {
            timeBeforeNextInteraction = 1f;
        }

        joueur = GameObject.FindGameObjectWithTag("Player");
        activeScene = SceneManager.GetActiveScene().name;
        float norme = Vector2.Distance(joueur.transform.position, transform.position);

        switch (activeScene)
        {
            case "Loge1":
                joueur = GameObject.FindGameObjectWithTag("Player");
                if (firstTimeInLoge1 == true)
                {
                    if (firstSentenceInLoge1 == false)
                    {
                        scriptSur.InitializedSencece("Rey : Où suis-je ? Ha oui, j’allais mettre mon costume et je me suis évanoui.");
                        etape++;
                        firstSentenceInLoge1 = true;
                    }
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        switch (etape)
                        {
                            case 1:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("Toujours ces crises d’angoisse avant de monter sur scène, il faut que je prenne des vacances.");
                                etape++;
                                break;
                            case 2:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("Je vais reprendre mes esprits et tout ira bien, après avoir mis mon costume,");
                                etape++;
                                break;
                            case 3:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("je serai dans mon personnage… Mais attend, je ne sais plus quelle pièce on joue ce soir,");
                                etape++;
                                break;
                            case 4:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("et encore moins qui je joue.");
                                etape++;
                                break;
                            case 5:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("Ça va aller, je vais me détendre en respirant lentement et tout me reviendra.");
                                etape++;
                                break;
                            case 6:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("Mais je ne peux pas dire que j’ai tout oublié, c’est trop la honte, et je risque de perdre mon rôle.");
                                etape++;
                                break;
                            case 7:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("Je vais chercher des indices dans le théâtre, et parler aux acteurs et aux équipes techniques.");
                                etape++;
                                break;
                            case 8:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("pour retrouver la mémoire.");
                                etape++;
                                break;
                            case 9:
                                scriptSur.EndDialogue();
                                etape = 0;
                                firstTimeInLoge1 = false;
                                break;
                        }
                    }
                }
                else if (norme < triggerDistance && Input.GetKeyDown(KeyCode.Space))
                {
                    switch (etape)
                    {
                        case 0:
                            scriptSur.InitializedSencece("Rey : Mmm, une affiche. Je mets souvent l’affiche de ma production dans ma loge,");
                            etape++;
                            break;
                        case 1:
                            scriptSur.EndDialogue();
                            scriptSur.InitializedSencece("pour m’imprégner de l’histoire. J’espère ne pas avoir oublié de la changer…");
                            etape++;
                            break;
                        case 2:
                            scriptSur.EndDialogue();
                            scriptSur.InitializedSencece("Donc normalement, je joue dans la pièce Hippolyte et Aricie de 1733,");
                            etape++;
                            break;
                        case 3:
                            scriptSur.EndDialogue();
                            scriptSur.InitializedSencece("écrite par Jean-Philippe Rameau,");
                            etape++;
                            break;
                        case 4:
                            scriptSur.EndDialogue();
                            scriptSur.InitializedSencece("j’adore les spectacles Baroque. Heureusement, je connais par cœur cette pièce, quel que soit mon personnage,");
                            etape++;
                            break;
                        case 5:
                            scriptSur.EndDialogue();
                            scriptSur.InitializedSencece("j'y arriverai. Mais vu qu'en plus je suis androgyne, je joue des rôles féminin et masculin.");
                            etape++;
                            break;
                        case 6:
                            scriptSur.EndDialogue();
                            scriptSur.InitializedSencece("Donc, je ne sais vraiment pas quel personnage je fais. Je vais aller dans d’autres salles.");
                            etape++;
                            break;
                        case 7:
                            scriptSur.EndDialogue();
                            etape = 0;
                            break;

                    }
                }
                break;
            case "Bureau":
                if (norme < triggerDistance && Input.GetKeyDown(KeyCode.Space))
                {
                    switch (etape)
                    {
                        case 0:
                            scriptSur.InitializedSencece(sentence);
                            etape++;
                            break;
                        case 1:
                            scriptSur.EndDialogue();
                            scriptDisplayTexte.EnabledTexte();
                            etape++;
                            break;
                        case 2:
                            scriptDisplayTexte.DisabledTexte();
                            etape = 0;
                            break;
                    }
                }
                break;
            case "AScene":
                if (norme < triggerDistance && Input.GetKeyDown(KeyCode.Space))
                {
                    if (firstTimeInAScene == true)
                    {
                        switch (etape)
                        {
                            case 0:
                                scriptSur.InitializedSencece("Rey : L'arrière-scène, il y a toujours pleins de personnes et de choses stockés entre les décors et les accessoires.");
                                etape++;
                                break;
                            case 1:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("J’espère trouver quelques infos sur mon rôle, car le temps passe vite.");
                                etape++;
                                break;
                            case 2:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("Ah voilà la Matelote, elle est en sirène");
                                etape++;
                                break;
                            case 3:
                                scriptSur.EndDialogue();
                                etape = 0;
                                firstTimeInAScene = false;
                                break;
                        }
                    }
                    else if (firstTimeInAScene == false && joueur.transform.position.x > 0)
                    {
                        switch (etape)
                        {
                            case 0:
                                scriptSur.InitializedSencece("Sirène : Hé toi-là! T'es-tu perdu ? Attention ! Ne pas faire naufrage en amour !");
                                etape++;
                                break;
                            case 1:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("Rey : Tu es déjà bien dans ton rôle.");
                                etape++;
                                break;
                            case 2:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("Sirène : Dommage que tu ne sois pas un de mes matelots, j’aurais bien aimé que tu sois auprès de moi.");
                                etape++;
                                break;
                            case 3:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("Mais ton rôle te va mieux, tu es trop délicat et trop jeune pour être un matelot.");
                                etape++;
                                break;
                            case 4:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("Rey : Heee, oui oui, c'est dommage.");
                                etape++;
                                break;
                            case 5:
                                scriptSur.EndDialogue();
                                etape = 0;
                                break;
                        }
                    }
                    else if (firstTimeInAScene == false && joueur.transform.position.x < 0)
                    {
                        switch (etape)
                        {
                            case 0:
                                scriptSur.InitializedSencece("Rey : Oh une épée, tu sais à qui elle est ?");
                                scriptDisplayTexte.EnabledTexte();
                                etape++;
                                break;
                            case 1:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("Sirène : Ben oui. C’est la tienne.  Il ne faut pas l’oublier, ça serait bête,");
                                etape++;
                                break;
                            case 2:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("c'est ton accessoire principal quand même.");
                                etape++;
                                break;
                            case 3:
                                scriptSur.EndDialogue();
                                scriptDisplayTexte.DisabledTexte();
                                etape = 0;
                                break;
                        }
                    }
                    break;
                }
                break;

            case "Couloir":
                if (norme < triggerDistance && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)))
                
                {
                    switch (etape)
                    {
                        case 0:
                            scriptSur.InitializedSencece("Faites votre choix, avec ENTRER");
                            etape++;
                            break;
                        case 1:
                            scriptSur.EndDialogue();
                            scriptDisplayTexte.EnabledTexte();
                            isInFinalChoice = true;
                            etape++;
                            break;
                        case 2:
                            if (Input.GetKeyDown(KeyCode.Return))
                            {
                                StartCoroutine(LoadScene_Game("Scene"));
                                break;
                            }
                            if (Input.GetKeyDown(KeyCode.Space))
                            {
                                scriptDisplayTexte.DisabledTexte();
                                scriptSur.EndDialogue();
                                isInFinalChoice = false;
                                etape = 0;
                                break;
                            }
                            break; 
                    }
                }
                break;
            case "Regie":
                if (norme < triggerDistance && Input.GetKeyDown(KeyCode.Space))
                {
                    switch (etape)
                    {
                        case 0:
                            //Etat fermer
                            regieFermer.SetActive(false);
                            regieOuverte.SetActive(true);
                            joueur.GetComponent<Script_Circle>().isSceneOuverte = true;
                            etape++;
                            break;
                        case 1:
                            //Etat ouvert
                            regieFermer.SetActive(true);
                            regieOuverte.SetActive(false);
                            joueur.GetComponent<Script_Circle>().isSceneOuverte = false;
                            etape = 0;
                            break;
                    }
                }
                break;
            case "Loge2":
                if (norme < triggerDistance && Input.GetKeyDown(KeyCode.Space))
                {
                    if (firstTimeInLoge2 == true)
                    {
                        switch (etape)
                        {
                            case 0:
                                scriptSur.InitializedSencece("Rey : Je sais qu’il y a toujours du monde qui se prépare dans cette loge,");
                                etape++;
                                break;
                            case 1:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("je vais me renseigner auprès d’eux...");
                                etape++;
                                break;
                            case 2:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("Il y a le maquilleur et un acteur, l’acteur est très poilu et a trois têtes, c’est Cerbère.");
                                etape++;
                                break;
                            case 3:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("Je vais rester naturel et aller discuter avec eux.");
                                etape++;
                                break;
                            case 4:
                                scriptSur.EndDialogue();
                                etape = 0;
                                firstTimeInLoge2 = false;
                                break;
                        }
                    }
                    else if (firstTimeInLoge2 == false)
                    {
                        switch (etape)
                        {
                            case 0:
                                scriptSur.InitializedSencece("Rey : Salut, tu arrives à te préparer ?");
                                etape++;
                                break;
                            case 1:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("Cerbère : Wouf Wouf");
                                etape++;
                                break;
                            case 2:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("Rey : Tu es toujours autant dans ton personnage de Cerbère.");
                                etape++;
                                break;
                            case 3:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("Cerbère : Wouf");
                                etape++;
                                break;
                            case 4:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("Maquilleur : (souffle) Il faut que je me dépêche de finir le maquillage de Cerbère ");
                                etape++;
                                break;
                            case 5:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("avant le début du spectacle. Il n’arrête pas de remuer dans tous les sens comme un chien,");
                                etape++;
                                break;
                            case 6:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("et il me dit que c’est pour se mettre dans son rôle.");
                                etape++;
                                break;
                            case 7:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("Heureusement que pour toi, ça a été rapide, juste un peu pour mettre ton visage en valeur.");
                                etape++;
                                break;
                            case 8:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("Je te remets un peu de poudre… C’est bon, tu es magnifique.");
                                etape++;
                                break;
                            case 9:
                                scriptSur.EndDialogue();
                                scriptSur.InitializedSencece("Rey : Merci, c’est très jolie. ");
                                etape++;
                                break;
                            case 10:
                                scriptSur.EndDialogue();
                                etape = 0;
                                break;

                        }
                    }
                }
                break;

        }
    }
    IEnumerator LoadScene_Game(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        while (current_alpha < 0.5f)
        {
            yield return null;
        }
        current_alpha = 0;
    }
}
