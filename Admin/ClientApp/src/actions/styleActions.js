import { FETCH_STYLES } from './types'
import { getStyles } from '../Api'


export const fetchStyles = (id) => dispatch => {
  getStyles(id).then((data)=> {
    dispatch({
      type: FETCH_STYLES,
      payload: data
    })
  })

}
