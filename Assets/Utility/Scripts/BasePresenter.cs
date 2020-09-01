using System.Collections.Generic;
using UnityEngine;

namespace Util {
    public abstract class BasePresenter<T> : IPresenter {
        protected readonly List<T> InputViews = new List<T>();
        [SerializeField] private GameObject[] views = null;

        public void Initialize() {
            foreach (var go in views) {
                var view = go.GetComponent<T>();
                if(view != null) InputViews.Add(view);
            }
        }
        public abstract void UpdateGUI(object source);
    }
}