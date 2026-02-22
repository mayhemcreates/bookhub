/* Helper for keyboard users to trap focus within a modal dialog. 
Should be called on keydown event of the modal container. */

export const useAccessibilityHelper = () => {
  const trapFocusHelper = (e: KeyboardEvent, parentEl: HTMLElement) => {
    if (e.key !== 'Tab') return

    const focusableSelectors = [
      'input:not([disabled])',
      'select:not([disabled])',
      'textarea:not([disabled])',
      'button:not([disabled])',
      'a[href]',
      '[tabindex]:not([tabindex="-1"])',
    ]

    const focusableElements = Array.from(
      parentEl.querySelectorAll<HTMLElement>(focusableSelectors.join(',')),
    ).filter((el) => el.offsetParent !== null) // Filter out hidden elements

    if (focusableElements.length === 0) return

    const firstElement = focusableElements[0] as HTMLElement
    const lastElement = focusableElements[focusableElements.length - 1] as HTMLElement
    const activeElement = document.activeElement as HTMLElement

    // Check if current focus is within the modal
    const isInModal = parentEl.contains(activeElement)

    if (e.shiftKey) {
      // Shift + Tab: moving backwards
      if (!isInModal || activeElement === firstElement) {
        e.preventDefault()
        lastElement.focus()
      }
    } else {
      // Tab: moving forwards
      if (!isInModal || activeElement === lastElement) {
        e.preventDefault()
        firstElement.focus()
      }
    }
  }

  const tabDetection = () => {
    const handleFirstTab = (e: KeyboardEvent) => {
      if (e.key === 'Tab') {
        document.body.classList.add('js-user-is-tabbing')
        window.removeEventListener('keydown', handleFirstTab)
      }
    }

    window.addEventListener('keydown', handleFirstTab)
  }
  return { trapFocusHelper, tabDetection }
}
