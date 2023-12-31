using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Canvas))]
[DisallowMultipleComponent]
public class MenuController : MonoBehaviour {
    [SerializeField]
    private Page InitialPage;
    [SerializeField]
    private GameObject FirstFocusItem;

    private Canvas RootCanvas;

    private Stack<Page> PageStack = new Stack<Page>();

    private void Awake() {
        RootCanvas = GetComponent<Canvas>();
    }

    private void Start() {
        if (FirstFocusItem != null) {
            EventSystem.current.SetSelectedGameObject(FirstFocusItem);
        }

        if (InitialPage != null) {
            PushPage(InitialPage);
        }
    }

    private void OnCancel() {
        if (RootCanvas.enabled && RootCanvas.gameObject.activeInHierarchy) {
            if (PageStack.Count != 0) {
                PopPage();
            }
        }
    }

    public bool IsPageOnStack(Page Page) {
        return PageStack.Contains(Page);
    }

    public bool IsPageOnTopOfStack(Page Page) {
        return PageStack.Count > 0 && Page == PageStack.Peek();
    }

    public void PushPage(Page Page) {
        Debug.Log("Push");

        Page.Enter(true);

        if (PageStack.Count > 0) {
            Page currentPage = PageStack.Peek();

            if (currentPage.ExitOnNewPagePush) {
                currentPage.Exit(false);
            }
        }

        PageStack.Push(Page);
    }

    public void PopPage() {
        if (PageStack.Count > 1) {
            Page page = PageStack.Pop();
            page.Exit(true);

            Page newCurrentPage = PageStack.Peek();
            if (newCurrentPage.ExitOnNewPagePush) {
                newCurrentPage.Enter(false);
            }
        }
        else {
            Debug.Log("Trying to pop a page but only 1 page remains on stack!");
        }
    }

    public void PopAllPages() {
        for (int i = 1; i < PageStack.Count; i++) {

        }
    }
}
