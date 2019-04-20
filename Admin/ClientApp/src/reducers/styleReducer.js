import { FETCH_STYLES, NEW_STYLE } from '../actions/types'

const intialState = {
  items: [],
  item: {}
}

export default function(state = intialState, action) {
  switch(action.type) {
    case FETCH_STYLES:
      return {
        ...state,
        items: action.payload
      }
    default:
      return state
  }
}