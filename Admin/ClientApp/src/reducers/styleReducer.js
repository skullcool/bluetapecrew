import { FETCH_STYLES } from '../actions/types'

const intialState = []

export default function(state = intialState, action) {
  switch(action.type) {
    case FETCH_STYLES:
      return action.payload
    default:
      return state
  }
}