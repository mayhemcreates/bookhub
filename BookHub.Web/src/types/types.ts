export interface Book {
  id: number
  title: string
  author: string
  isbn: string
  rating: number
  noteStatus: boolean
  comments: string
  imageUrl: string
}

export enum ModalAction {
  ADD = 'add',
  EDIT = 'edit',
  DELETE = 'delete',
}

export enum ViewOption {
  GRID = 'grid',
  LIST = 'list',
}
