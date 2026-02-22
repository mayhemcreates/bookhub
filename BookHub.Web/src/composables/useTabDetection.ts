// Enables focus styles for keyboard users

export const useTabDetection = () => {
  const handleFirstTab = (e: KeyboardEvent) => {
    if (e.key === 'Tab') {
      document.body.classList.add('js-user-is-tabbing')
      window.removeEventListener('keydown', handleFirstTab)
    }
  }

  window.addEventListener('keydown', handleFirstTab)
}
