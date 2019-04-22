import { DELETE_STYLE, FETCH_STYLES } from '../actions/types'

const intialState = []

export default function(state = intialState, action) {
  switch(action.type) {
    case FETCH_STYLES:
      return action.payload
    case DELETE_STYLE:
      return state.filter(x=>x.id !== action.payload)
    default:
      return state
  }
}