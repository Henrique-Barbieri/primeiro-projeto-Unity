using DG.Tweening;

public static class tweeningExtensions
{
    public static void KillIfActive(this Tweener tweener){
         if(tweener != null && tweener.IsActive()){
            tweener.Kill();
        }
    }
}
