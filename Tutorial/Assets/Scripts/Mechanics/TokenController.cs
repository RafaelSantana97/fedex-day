using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This class animates all token instances in a scene.
    /// This allows a single update call to animate hundreds of sprite 
    /// animations.
    /// If the tokens property is empty, it will automatically find and load 
    /// all token instances in the scene at runtime.
    /// </summary>
    public class TokenController : MonoBehaviour
    {
        [Tooltip("Frames per second at which tokens are animated.")]
        public float frameRate = 12;
        [Tooltip("Instances of tokens which are animated. If empty, token instances are found and loaded at runtime.")]
        public TokenInstance[] tokens;

        float nextFrameTime = 0;

        [ContextMenu("Find All Tokens")]
        void FindAllTokensInScene()
        {
            tokens = UnityEngine.Object.FindObjectsOfType<TokenInstance>();
        }

        void Awake()
        {
            //if tokens are empty, find all instances.
            //if tokens are not empty, they've been added at editor time.
            if (tokens.Length == 0)
                FindAllTokensInScene();
            //Register all tokens so they can work with this controller.
            for (var i = 0; i < tokens.Length; i++)
            {
                tokens[i].tokenIndex = i;
                tokens[i].controller = this;
            }
        }

        void Update()
        {            
            //if it's time for the next frame...
            if (Time.time - nextFrameTime > (1f / frameRate))
            {
                //update all tokens with the next animation frame.
                for (var i = 0; i < tokens.Length; i++)
                {
                    var token = tokens[i];
                    //if token is null, it has been disabled and is no longer animated.
                    if (token != null)
                    {
                        if (token.collected)
                        {
                            if (token.isCoin)
                            {
                                Schedule<PlayerHealthAddCoin>();
                            } else
                            {
                                Schedule<PlayerHealthIncrement>();
                            }
                            token.gameObject.SetActive(false);
                            tokens[i] = null;                            
                        }
                    }
                }
                //calculate the time of the next frame.
                nextFrameTime += 1f / frameRate;
            }
        }

    }
}