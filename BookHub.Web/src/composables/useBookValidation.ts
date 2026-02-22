import { ref, computed } from 'vue'

type FieldName = 'title' | 'author' | 'isbn' | 'rating' | 'comments'

export function useBookValidation(isEditMode: () => boolean) {
  const title = ref('')
  const author = ref('')
  const isbn = ref('')
  const rating = ref(0)
  const comments = ref('')
  const hasAttemptedSubmit = ref(false)

  // Track which fields have been focused after validation errors
  const clearedFields = ref<Set<FieldName>>(new Set())

  const clearFieldError = (field: FieldName) => {
    clearedFields.value.add(field)
  }

  const resetClearedFields = () => {
    clearedFields.value = new Set()
  }

  const titleErrors = computed(() => {
    const errors: string[] = []
    if (!title.value.trim()) errors.push('Title is required')
    else if (title.value.length > 100) errors.push('Title cannot exceed 100 characters')
    return errors
  })

  const authorErrors = computed(() => {
    const errors: string[] = []
    if (!author.value.trim()) errors.push('Author is required')
    else if (author.value.length > 100) errors.push('Author cannot exceed 100 characters')
    return errors
  })

  const isbnErrors = computed(() => {
    const errors: string[] = []
    if (!isbn.value.trim()) errors.push('ISBN is required')
    else if (isbn.value.length > 100) errors.push('ISBN cannot exceed 100 characters')
    return errors
  })

  const ratingErrors = computed(() => {
    const errors: string[] = []
    if (rating.value > 5) errors.push('Rating cannot exceed 5')
    if (rating.value > 0 && !comments.value.trim())
      errors.push('A comment is required when providing a rating')
    return errors
  })

  const commentsErrors = computed(() => {
    const errors: string[] = []
    if (comments.value.toLowerCase().includes('horrible'))
      errors.push('The word "horrible" is not allowed in comments')
    return errors
  })

  const allErrors = computed(() => {
    if (isEditMode()) {
      return [...ratingErrors.value, ...commentsErrors.value]
    }
    return [
      ...titleErrors.value,
      ...authorErrors.value,
      ...isbnErrors.value,
      ...ratingErrors.value,
      ...commentsErrors.value,
    ]
  })

  const isFormValid = computed(() => allErrors.value.length === 0)

  const fieldIsValid = computed(() => ({
    title:
      hasAttemptedSubmit.value && titleErrors.value.length > 0 && !clearedFields.value.has('title'),
    author:
      hasAttemptedSubmit.value &&
      authorErrors.value.length > 0 &&
      !clearedFields.value.has('author'),
    isbn:
      hasAttemptedSubmit.value && isbnErrors.value.length > 0 && !clearedFields.value.has('isbn'),
    rating:
      hasAttemptedSubmit.value &&
      ratingErrors.value.length > 0 &&
      !clearedFields.value.has('rating'),
    comments:
      hasAttemptedSubmit.value &&
      commentsErrors.value.length > 0 &&
      !clearedFields.value.has('comments'),
  }))

  return {
    title,
    author,
    isbn,
    rating,
    comments,
    hasAttemptedSubmit,
    allErrors,
    isFormValid,
    fieldIsValid,
    clearFieldError,
    resetClearedFields,
  }
}
